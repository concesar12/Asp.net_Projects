namespace PartialViewsExample.Models
    //In here we are going to create the properties to send to the partial view
{
    public class ListModel
    {
        public string ListTitle { get; set; } = "";
        public List<string> ListItems { get; set; } = new List<string>();
    }
}
