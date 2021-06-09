using Microsoft.AspNetCore.Html;
using System;
using System.ComponentModel.DataAnnotations;


namespace AuntificationMetanit.Models
{
    public class Case : Record
    {
        [Display(Name = "Дата окончания")]

        public DateTime DateEnd { get; set; }

        [Display(Name = "Дело")]
        public new string Discriminator { get; set; }

        public override string ToString()
        {
            return $"Тема: {Theme}  Дата окончания: {DateEnd}    Дата начала: {DateBegin}";
        }


        public override HtmlString GetInfo()
        {
            return new HtmlString($"<td>Тема: {Theme} </td> <td>Дата начала: {DateBegin.ToString("f")} </td>" +
                $"<td>Дата окончания: {DateEnd.ToString("f")} </td>");
        }

    }
}
