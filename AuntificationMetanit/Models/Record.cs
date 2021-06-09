using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Html;

namespace AuntificationMetanit.Models
{
    public class Record
    {
        [Key]
        [ScaffoldColumn(false)]
        public Guid RecordId { get; set; }

        [ForeignKey("UserInfo")]
        [ScaffoldColumn(false)]
        public Guid UserId { get; set; }


        [Display(Name = "Тема")]
        public string Theme { get; set; }

        [Display(Name = "Дата начала")]
        public DateTime DateBegin { get; set; }

        [ScaffoldColumn(false)]

        [Display(Name = "Памятка")]
        public string Discriminator { get; set; }
        public override string ToString()
        {
           return $"Тема: {Theme}      Дата начала: {DateBegin}";
        }
        public virtual HtmlString GetInfo()
        {
            return new HtmlString($"<td>Тема: {Theme} </td> <td>Дата начала: {DateBegin.ToString("f")} </td>");
        }
    }
}
