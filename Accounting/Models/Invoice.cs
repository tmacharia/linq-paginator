using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Accounting.Models
{
    public class Invoice
    {
        public Invoice()
        {
            Items = new HashSet<InvoiceItem>();
        }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public Location CompanyLocation { get; set; }
        /// <summary>
        /// Exact date when the invoice is or will be sent/submitted
        /// to the client
        /// </summary>
        public DateTime? SubmissionDate { get; set; }
        /// <summary>
        /// Invoice For:
        /// Company name, Street address, City, State, Postal Code
        /// </summary>
        public string InvoiceFor { get; set; }
        public string PayableTo { get; set; }
        public string InvoiceNumber { get; set; }
        public string Project { get; set; }
        public DateTime? DueDate { get; set; }

        public HashSet<InvoiceItem> Items { get; private set; }
        public string Notes { get; set; }
        public double Additions { get; set; }
        public double Adjustments { get; set; }
        public double SubTotal
        {
            get
            {
                Items = Items ?? new HashSet<InvoiceItem>();
                return Items.Sum(x => x.TotalPrice);
            }
        }
        public double FinalTotal
        {
            get
            {
                return SubTotal + Additions - Adjustments;
            }
        }
    }
}
