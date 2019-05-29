using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata;
using System;


namespace TEST2.Helpers
{
    public static class SmallListHelper
    {
        public static IHtmlContent SmallList(this IHtmlHelper htmlHelper, string firstName, string lastName, long pesel, DateTime dateOfBirth, string email)
        {
            var html = " <ul class='w3-ul'>";
                html += "    <li>FirstName: "+ firstName + "</li>";
                html += "    <li>LastName: " + lastName + "</li>";
                html += "    <li>Pesel: "+ pesel + "</li>";
                html += "    <li>DateOfBirth: " + dateOfBirth + "</li>";
                html += "    <li>E-mail: " + email + "</li>";
                html += " </ul>";
         
            return new HtmlString(html);
        }

        /*  var html =  "<table>";
                  html += " <thead>";
                  html += "        <tr>";
                  html += "           <th> Firstname </th>";
                  html += "        </tr>";
                  html += "        <tr>";
                  html += "           <th> Lastname </th>";
                  html += "        </tr>";
                  html += "        <tr>";
                  html += "           <th> E - mail </th>";
                  html += "        </tr>";
                  html += " </thead >";
                  html += " <tbody>";
                  html += "        <tr>";
                  html += "            <td>"+ firstName +"</td>";
                  html += "        </tr>";
                  html += "        <tr>";
                  html += "            <td>"+ lastName +"</td>";
                  html += "        </tr>";
                  html += "        < tr >";
                  html += "        <td>"+ email +"</td>";
                  html += "        </tr>";
                  html += " </tbody>";
                  html += "</table>";
                  */
    }
}
