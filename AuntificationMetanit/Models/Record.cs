using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Html;

namespace AuntificationMetanit.Models
{
    public class Record
    {
        [Key]
        public Guid RecordId { get; set; }

        [ForeignKey("UserInfo")]
        public Guid UserId { get; set; } 

       public string Theme { get; set; }
       public DateTime DateBegin { get; set; }

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
