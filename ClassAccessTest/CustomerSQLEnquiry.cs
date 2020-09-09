#define NOUSESQL
#undef NOUSESQL
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace ClassAccessTest
{
	public partial class CustomerSQLEnquiry : Form
	{
		public CustomerSQLEnquiry ( )
		{
			InitializeComponent ( );
			firstname.Enabled = true;
			lastname.Enabled = true;
			address1.Enabled = true;
			address2.Enabled = true;
			town.Enabled = true;
			county.Enabled = true;
			postcode.Enabled = true;
			mobile.Enabled = true;
			phone.Enabled = true;
		}

		private void exitbutton_Click (object sender, EventArgs e)
		{
			this.Close ( );
		}

		//#if NOUSESQL
		//*******************************************************************************************************************
		public void findcustbutton_Click (object sender, EventArgs e)
		//*******************************************************************************************************************
		{
			// find cust data
			// here we will use SQL
			/*            if (!SQLAccess.SQLconnection)
						{
							MessageBox.Show("Your are NOT connected to the SQL Server !  Please use the SQL Connect  button");
							return;
						}
						// First try just reads everything from SQL table and returns 
						SqlDataReader myReader = null;
						SqlCommand myCommand = new SqlCommand("use Bankaccount", SQLAccess.cnn);
						myReader = myCommand.ExecuteReader();
						while (myReader.Read())
						{
							Output.AppendText(myReader["Column1"].ToString());
							Output.AppendText(myReader["Column2"].ToString());
						}
			 */
		}
		//*******************************************************************************************************************
		public void updatecust_Click (object sender, EventArgs e)
		//*******************************************************************************************************************
		{
			info.Enabled = false;
			// now update the LinkedList entry
			string Searchterm = textBoxx.Text;
			{
				Customer Cust = Customer.GetCustomerAccount (Searchterm);
				if ( Cust.CustomerNumber != 0 )
				{
					//Update the LinkedList                
					foreach ( var C in Customer.CustomersLinkedList )
					{
						int custno = Convert.ToInt32 (Searchterm);
						if ( C.CustomerNumber == custno )
						{   // got it update data
							C.FirstName = firstname.Text;
							C.LastName = lastname.Text;
							string dob = dob1.Text + "/" + dob2.Text + " / " + dob3.Text;
							C.DOB = Convert.ToDateTime (dob);
							C.Address1 = address1.Text;
							C.Address2 = address2.Text;
							C.Town = town.Text;
							C.County = county.Text;
							C.PostCode = postcode.Text;
							C.PhoneNumber = phone.Text;
							C.MobileNumber = mobile.Text;
							C.PostCode = postcode.Text;
							// now update the CustomerAccount itself.
							Cust.FirstName = firstname.Text;
							Cust.LastName = lastname.Text;
							Cust.DOB = Convert.ToDateTime (dob);
							Cust.Address1 = address1.Text;
							Cust.Address2 = address2.Text;
							Cust.Town = town.Text;
							Cust.County = county.Text;
							Cust.MobileNumber = mobile.Text;
							Cust.PostCode = postcode.Text;
							Cust.PhoneNumber = phone.Text;
							break;      // all finished
						}
					}
					Output.AppendText ("Customer Account " + Searchterm + " details identified...\r\n");
					Output.ScrollToCaret ( );
					info.ForeColor = Color.Black;
					info.Text = "Customer Account  " + Searchterm + " updated successfully";
					System.Media.SystemSounds.Asterisk.Play ( );
				}
				else
				{
					Output.AppendText ("Customer Account " + Searchterm + " could not be updated... \r\n");
					Output.ScrollToCaret ( );
					info.ForeColor = Color.Red;
					info.Text = "Customer Account  " + Searchterm + " could not be updated... ";
					System.Media.SystemSounds.Question.Play ( );
				}
				// write it back to disk before we dispose of it
//				Cust.Dispose ( );
			}
		}

		// clear all the fields
		private void cleardata_Click (object sender, EventArgs e)
		{
			firstname.Text = "";
			lastname.Text = "";
			address1.Text = "";
			address2.Text = "";
			town.Text = "";
			county.Text = "";
			postcode.Text = "";
			phone.Text = "";
			mobile.Text = "";
			postcode.Text = "";
		}

		private void Output_TextChanged (object sender, EventArgs e)
		{

		}
	}       // End CLASS
}
/*
#else
//*******************************************************************************************************************
    public void findcustbutton_Click(object sender, EventArgs e)
//*******************************************************************************************************************
    {

        //first we will try the old way using files on disk
        info.Enabled = false;
        string Searchterm = Bank . V.ToString() + textBox1.Text;
        Customer Cust = Customer.GetCustomerAccount(Searchterm);
        if (Cust.CustomerNumber != 0)
        {
            // go ahead and  update the customer data on screen
            firstname.Text = Cust.FirstName;
            lastname.Text = Cust.LastName;
            dob1.Text = Cust.DOB.ToShortDateString();
            address1.Text = Cust.Address1;
            address2.Text = Cust.Address2;
            town.Text = Cust.Town;
            county.Text = Cust.County;
            postcode.Text = Cust.PostCode;
            mobile.Text = Cust.MobileNumber;
            phone.Text = Cust.PhoneNumber;
            // Enable the fields
            firstname.Enabled = true;
            lastname.Enabled = true;
            dob1.Enabled = true;
            dob2.Enabled = true;
            dob3.Enabled = true;
            address1.Enabled = true;
            address2.Enabled = true;
            town.Enabled = true;
            county.Enabled = true;
            postcode.Enabled = true;
            mobile.Enabled = true;
            phone.Enabled = true;
            updatecust.Enabled = true;

            Output.AppendText("Customer Account " + Searchterm + " details identified...\r\n");
            Output.ScrollToCaret();
            info.ForeColor = Color.Black; // Black
            info.Text = "Customer Account " + Searchterm + " details identified...";
            System.Media.SystemSounds.Asterisk.Play();
        }
        else
        {
            info.Enabled = true;
            info.ForeColor = Color.Red;
            Output.AppendText("Customer Account  " + Searchterm + " cannot be found !!\r\n");
            Output.ScrollToCaret();
            info.Text = "Customer Account cannot  " + Searchterm + " be found !!";
            System.Media.SystemSounds.Question.Play();
        }
    }


//*******************************************************************************************************************
    public void updatecust_Click(object sender, EventArgs e)
//*******************************************************************************************************************
    {
        info.Enabled = false;
        // now update the LinkedList entry
        string Searchterm = textBoxx.Text;
        {
            using Customer Cust = Customer.GetCustomerAccount(Searchterm);
            if (Cust.CustomerNumber != 0)
            {
                //Update the LinkedList                
                foreach (var C in Customer.CustomersLinkedList)
                {
                    int custno = Convert.ToInt32(Searchterm);
                    if (C.CustomerNumber == custno)
                    {   // got it update data
                        C.FirstName = firstname.Text;
                        C.LastName = lastname.Text;
                        string dob = dob1.Text + "/" + dob2.Text + " / " + dob3.Text;
                        C.DOB = Convert.ToDateTime(dob);
                        C.Address1 = address1.Text;
                        C.Address2 = address2.Text;
                        C.Town = town.Text;
                        C.County = county.Text;
                        C.PostCode = postcode.Text;
                        C.PhoneNumber = phone.Text;
                        C.MobileNumber = mobile.Text;
                        C.PostCode = postcode.Text;
                        // now update the CustomerAccount itself.
                        Cust.FirstName = firstname.Text;
                        Cust.LastName = lastname.Text;
                        Cust.DOB = Convert.ToDateTime(dob);
                        Cust.Address1 = address1.Text;
                        Cust.Address2 = address2.Text;
                        Cust.Town = town.Text;
                        Cust.County = county.Text;
                        Cust.MobileNumber = mobile.Text;
                        Cust.PostCode = postcode.Text;
                        Cust.PhoneNumber = phone.Text;
                        break;      // all finished
                    }
                }
                Output.AppendText("Customer Account " + Searchterm + " details identified...\r\n");
                Output.ScrollToCaret();
                info.ForeColor = Color.Black;
                info.Text = "Customer Account  " + Searchterm + " updated successfully";
                System.Media.SystemSounds.Asterisk.Play();
            }
            else
            {
                Output.AppendText("Customer Account " + Searchterm + " could not be updated... \r\n");
                Output.ScrollToCaret();
                info.ForeColor = Color.Red;
                info.Text = "Customer Account  " + Searchterm + " could not be updated... ";
                System.Media.SystemSounds.Question.Play();
            }
            // write it back to disk before we dispose of it
            Cust.Dispose();
        }
    }

    // clear all the fields
    private void cleardata_Click(object sender, EventArgs e)
    {
        firstname.Text = "";
        lastname.Text = "";
        address1.Text = "";
        address2.Text = "";
        town.Text = "";
        county.Text = "";
        postcode.Text = "";
        phone.Text = "";
        mobile.Text = "";
        postcode.Text = "";
    }
}       // End CLASS
#endif
}
/*
SqlCommand myCommand = new SqlCommand("INSERT INTO table (Column1, Column2) " +
                                 "Values ('string', 1)", SQLAccess.cnn);
// execute the request
myCommand.ExecuteNonQuery();

// - or - 

myCommand.CommandText = "INSERT INTO table (Column1, Column2) " +
                "Values ('string', 1)";
// execute the request
myCommand.ExecuteNonQuery();



*/