using System;
using System.IO;
using System.Windows.Forms;

namespace ClassAccessTest
{
    public partial class ReadBankTextFile : Form
    {
        public static decimal balance = 55.67M;
        public string currentaccount = "";
        //======================================================================
        public ReadBankTextFile()
        //======================================================================
        {
            InitializeComponent();
            string[] fullpath = null;
            char[] c = { '\\' };
            string path = BankAccount.ReadBankFilePath();
            path += "Textfiles\\";
            string[] files = Directory.GetFiles(path);
            if (files.Length > 0)
            {
                foreach (string s in files)
                {
                    if (!s.Contains("BankObject"))
                        continue;
                    fullpath = s.Split(c);
                    string fn = fullpath[7];
                    string numb = fn.Substring(10);
                    fn = numb.Substring(0, 7);
                    AccountNumber.Items.Add(fn);
                }
                try
                {
                    AccountType.SelectedIndex = 0;
                    AccountNumber.SelectedIndex = 0;
                    currentaccount = AccountNumber.SelectedItem.ToString();
                    object sender = null;
                    EventArgs e = null;
                    FindFile_Click_1(sender, e);
                    info.Text = "Select the Bank Account to View/Edit  from dropdown list above...";
                }
                catch { return; }
            }
        }

        //======================================================================
        private void FindFile_Click_1(object sender, EventArgs e)
        //======================================================================
        {
            if (AccountNumber.SelectedItem == null) return;
            string sel = AccountNumber.SelectedItem.ToString();
            if (Convert.ToInt32(AccountNumber.Text) < Bank.V || Convert.ToInt32(AccountNumber.Text) > Bank.V)
            {
                MessageBox.Show("Invalid Bank Account # entered. range is " + Bank.V.ToString() + " and upwards !"); return;
            }
            string path = BankAccount.ReadBankFilePath() + "Textfiles\\bankobject" + sel + ".txt";
            if (!File.Exists(path))
            { MessageBox.Show("Invalid Bank Account # entered. range is " + Bank.V.ToString() + " and upwards !"); return; }
            /*
						Customer C = ( Customer ) DataArray.FindCustFromArray( sel );
						SB = SerializeData . ReadBankFromDisk ( AccountNumber . Text );
						string str = SB . ToString ( );
			*/

            notes.Text = "DO NOT edit the data in this window, just edit it in the data fields.\r\n"
                            + "All/Any available data item can be changed, and once saved, it will be changed permanently throughout the System.\n\r\n";
            string input = File.ReadAllText(path);
            string[] data = input.Split(',');
            if (data.Length > 0)
            {
                notes.Text += input;
                custno.Text = data[1];
                Int16 selindx = Convert.ToInt16(data[2]);
                if (selindx == -1)
                    AccountType.SelectedIndex = 0;
                else
                    AccountType.SelectedIndex = selindx - 1;
                AccountBalance.Text = data[3];
                OpenDate.Text = data[4];
                Interest.Text = data[6];
                if (data[7] == "1\r\n")
                    status.Text = "Active";
                else status.Text = "Suspended";
            }
            info.Text = "Your Bank Account selection for A/C " + AccountNumber.Text + " has been loaded successfully...";

        }

        //======================================================================
        private void clearform_Click_1(object sender, EventArgs e)
        //======================================================================
        {       // clar all data froim fields
            notes.Text = ""; AccountNumber.Text = "";
            AccountBalance.Text = ""; ;
            OpenDate.Text = "";
            Interest.Text = "";
            custno.Text = "";
            AccountNumber.Focus();
        }


        //======================================================================
        private void rewrite_Click(object sender, EventArgs e)
        //======================================================================
        {
            string output = "";
            if (notes.Text == "" || AccountNumber.Text == "" || AccountBalance.Text == "" || OpenDate.Text == "" || Interest.Text == "" || custno.Text == "")
            {
                MessageBox.Show("One or more data items are Empty - All fields must be completed before saving it ..." +
                                               "\nRecommeded action is to use the DropDown list to reselect a valid Bank Account", "Data Validation ERROR");
                info.Text = "One or more data items are Empty - All fields must be completed before saving it ..."; return;
            }
            string stat;
            if (status.Text == "Active") stat = "1"; else stat = "0";
            int type = AccountType.SelectedIndex + 1;
            // format is "Bank A/c #  + "," + Customer A/c # + "," + A/c Type + "," + Balance + "," + Date Opened (short) + "," + Date Closed (short) + "," + Interest + "," + Status (0/1)+ "\r\n"
            output = AccountNumber.Text + "," + custno.Text + "," + type.ToString() + "," + AccountBalance.Text + ",";
            output += Convert.ToDateTime(OpenDate.Text).ToShortDateString() + "," + Convert.ToDateTime("01/01/0001").ToShortDateString() + "," + Interest.Text;
            output += "," + stat + "\r\n";
            string path = BankAccount.ReadBankFilePath();
            path += "Textfiles\\BankObject" + AccountNumber.Text + ".txt";
            if (File.Exists(path))
                File.Delete(path);      // you gotta delete them first, else it appends the data constantly
            File.AppendAllText(path, output);

            // update the bank object 
            path = BankAccount.ReadBankFilePath();
            path += "Bankobject" + AccountNumber.Text + ".bnk";

            // read the bank a/c in fresh from disk so it is clean
            BankAccount Bank = SerializeData.ReadBankAccountFromDisk(path);
            if (Bank == null)
            { MessageBox.Show("Bank Account Object file cannot be loaded (or saved)!", "Bank Object Error"); return; }
            Int32 bankno = Bank.BankAccountNumber;
            // update the Bank object
            Bank.AccountType = Convert.ToInt16(AccountType.SelectedIndex);
            Bank.AccountType++;// cos th reindex starts at ZERO !!
            Bank.Balance = Convert.ToDecimal(AccountBalance.Text);
            Bank.InterestRate = Convert.ToDecimal(Interest.Text);
            string banknostring = Bank.BankAccountNumber.ToString();

            //Update the version in Bank Array
            int index = DataArray.ArrayFindBank(Bank);
            DataArray.BankNo[index] = Bank;

            // Update the version in our Bank LinkedList
            foreach (var B in BankAccount.BankAccountsLinkedList)
            {
                if (B.BankAccountNumber == bankno)
                {   // got it, rpelace with our new one
                    BankAccount.BankAccountsLinkedList.Remove(B);
                    BankAccount.BankAccountsLinkedList.AddLast(Bank);
                    break;
                }
            }
            // This saves the bank LinkedList to both an object file and a Text file
            Lists.SaveAllBankAccountListData();
            // write theBank object to disk
            SerializeData.WriteBankAccountToDiskAndText(Bank, path);
            // Add a bank Transaction
            BankTransaction newbankaccount = new BankTransaction(Bank.DateOpened, Bank.AccountType, Bank.CustAccountNumber,
                                                                                                    Bank.BankAccountNumber, Bank.Balance, "Bank details edited from Textfile input", Bank.Status);
            BankTransaction.allBankTransactions.AddLast(newbankaccount);
            // that's it ***ALL***all Bank Data structures have been updated        
            info.Text = "Bank Account data has been fully updated throughout System";
        }

        //======================================================================
        private void AccountNumber_DropDownClosed(object sender, EventArgs e)
        //======================================================================
        {
            FindFile_Click_1(sender, e);
        }

        //======================================================================
        private void exit_Click(object sender, EventArgs e)
        //======================================================================
        {
            Close();
        }
    }
}
