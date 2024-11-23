
using System.Text.RegularExpressions;

namespace _1_лабораторная.Models
{
    public class Position
    {
        public int PositionId { get; set; }
        public string Name { get; set; }

        public bool isValidName()
        {
            return Regex.Match(Name, @"^[А-Я][а-я]*$").Success;
        }
    }
}
