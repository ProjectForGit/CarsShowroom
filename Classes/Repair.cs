using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsShowroom.Classes
{
    public partial class Repair
    {
        private int cost;
        private DateTime receiptDate;
        private DateTime issueDate;
        private string problem;

        public int RepairId { get; set; }
        public int AccessoryId { get; set; }
        public Accessory Accessory { get; set; }
        public int Cost
        {
            get => cost; set
            {
                cost = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(cost)));
            }
        }
        public DateTime ReceiptDate
        {
            get => receiptDate; set
            {
                receiptDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(receiptDate)));
            }
        }
        public DateTime IssueDate
        {
            get => issueDate; set
            {
                issueDate = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(issueDate)));
            }
        }
        public string Problem
        {
            get => problem; set
            {
                problem = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(problem)));
            }
        }

        public override string ToString()
        {
            return Problem;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
