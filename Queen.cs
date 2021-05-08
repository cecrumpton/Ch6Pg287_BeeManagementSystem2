using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch6Pg287_BeeManagementSystem2
{
    class Queen : Bee
    {
        public Queen(Worker[] workers, double weightMg ) : base(weightMg)
        {
            this.workers = workers;
            this.weightMg = weightMg;
        }

        private Worker[] workers;
        private int shiftNumber = 0;
        private double weightMg;

        public bool AssignWork(string job, int numberOfShifts)
        {
            for (int i = 0; i < workers.Length; i++)
                if (workers[i].DoThisJob(job, numberOfShifts))
                    return true;
            return false;
        }

        public string WorkTheNextShift()
        {
            double honeyConsumed = HoneyConsumptiionRate();
            shiftNumber ++;
            string report = "Report for shift #" + shiftNumber + "\r\n";
            for (int i = 0; i < workers.Length; i++)
            {
                if (workers[i].DidYouFinish())
                    report += "Worker #" + (i+1).ToString() + " finished the job\r\n";

                if (String.IsNullOrEmpty(workers[i].CurrentJob))
                    report = report + "Worker #" + (i + 1).ToString() + " is not working\r\n";
                else
                {
                    if (workers[i].ShiftsLeft > 0)
                        report += "Worker #" + (i + 1).ToString() + " is doing " + workers[i].CurrentJob + " for " + workers[i].ShiftsLeft + " more shifts.\r\n";
                    else
                        report += "Worker #" + (i + 1).ToString() + " will be done with " + workers[i].CurrentJob + " after this shift.\r\n";
                }
                honeyConsumed += workers[i].HoneyConsumptiionRate();
            }
            report += "Total honey consumed for the shift: " + honeyConsumed + " units";
            return report;
        }
    }
}
//tells the workers to work 1 shift
//checks the worker's status
//adds one line to the shift report

//for loop that executes 2 if statements for each worker in the Workers array
//first if - checks if worker finished the job
//second if - checks if worker is currently doing a job, if so it prints how many more shifts it's working

//loops through the queen object's workers array and attempts to assign the job to each
//Worker using its DoThisJob() method.
//Worker object then checks its jobsICanDo string array to see if it can do the job
//if it can, it sets its private shiftsToWork field to the job duration
//its currentJob to the job,
//and its shiftsWorked to zero.

//When it works a shift, it increases shiftsWorked by one.
//ShiftsLeft property returns shiftsToWork - shiftsWorked, the queen uses to see how many shifts are left

//return true if it finds a worker for the shift, false if it can't