using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuntificationMetanit.Models
{
    public class Meeting : Record
    {

        public string Place { get; set; }
        public DateTime DateEnd { get; set; }

        public override string ToString()
        {
            return $"Тема: {Theme}  Место: {Place}  Дата окончания: {DateEnd}    Дата начала: {DateBegin}";
        }
        public override HtmlString GetInfo()
        {
            return new HtmlString($"<td>Тема: {Theme} </td> <td>Дата начала: {DateBegin.ToString("f")} </td> " +
                $"<td>Дата начала: {DateEnd.ToString("f")} </td> <td>Место: {Place} </td>") ;
        }
    }
}
