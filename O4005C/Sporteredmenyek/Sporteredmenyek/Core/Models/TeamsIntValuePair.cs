namespace Sporteredmenyek.Core.Models
{
    public struct TeamsIntValuePair
    {

        public int Home { get; set; }
        public int Away { get; set; }
        public TeamsIntValuePair(int home, int away)
        {
            Home = home;
            Away = away;
        }
    }
}
