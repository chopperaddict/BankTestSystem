using System;
using System . Collections . Generic;
using System . ComponentModel;
using System . Data;
using System . Drawing;
using System . Linq;
using System . Text;
using System . Threading . Tasks;
using System . Windows . Forms;

namespace ClassAccessTest
{
	public partial class SqlDataView : Form
	{
		public SqlDataView ( )
		{
			InitializeComponent ( );
			SQLdataGridView . DataSource = delegatesBindingSource1;
		}

		private void dataGridView1_CellContentClick ( object sender , DataGridViewCellEventArgs e )
		{

		}
	}
}
