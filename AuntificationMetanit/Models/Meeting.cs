using Microsoft.AspNetCore.Html;
using System;
using System.ComponentModel.DataAnnotations;

namespace AuntificationMetanit.Models
{
    public class Meeting : Record
    {
        [Display(Name = "Место")]
        public string Place { get; set; }

        [Display(Name = "Дата окончания")]
        public DateTime DateEnd { get; set; }

        [ScaffoldColumn(false)]
        public new string Discriminator { get; set; }

        public override string ToString()
        {
            return $"Тема: {Theme}  Место: {Place}  Дата окончания: {DateEnd}    Дата начала: {DateBegin}";
        }
        public override HtmlString GetInfo()
        {
            return new HtmlString($"<td>Тема: {Theme} </td> <td>Дата начала: {DateBegin.ToString("f")} </td> " +
                $"<td>Дата окончания: {DateEnd.ToString("f")} </td> <td>Место: {Place} </td>") ;
        }
    }
}
