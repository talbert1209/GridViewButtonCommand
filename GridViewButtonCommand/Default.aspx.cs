using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GridViewButtonCommand
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var cars = new List<Car>() {
                new Car { CarId=Guid.NewGuid(), Make="BMW", Model="528i", Year=2010 },
                new Car {CarId=Guid.NewGuid(), Make="Toyota", Model="4Runner", Year=2010},
                new Car {CarId=Guid.NewGuid(), Make="Hyundai", Model="Elantra", Year=2013}
            };

            GridView.DataSource = cars;
            GridView.DataBind();
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = GridView.Rows[index];

            // This is a bit risky... take great caution.

            var make = row.Cells[1].Text;
            var model = row.Cells[2].Text;
            var value = row.Cells[4].Text;

            // You want to convert fields to their original data type.
            var carId = Guid.Parse(value);

            resultLabel.Text = $"{make} {model} {carId}";
        }
    }

    public class Car 
    {
        public Guid CarId { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
    }
}