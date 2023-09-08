namespace Employe.Data
{
    public class Dup
    {
        public static bool Duplicate(List<string> month, string monthName)
        {

            foreach (var x in month) if (x == monthName) return true;

            return false;
        }
    }
}
