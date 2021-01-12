using Microsoft.UI.Xaml.Controls;
using Syncfusion.UI.Xaml.Data;
using Syncfusion.UI.Xaml.TreeGrid;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace SfTreeGridDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
	{		
		public MainPage()
		{			
			this.InitializeComponent();						
		}		

		IPropertyAccessProvider Provider;
		Person dataRow = new Person();
		private void textbox_TextChanged(object sender, TextChangedEventArgs e)
        {
			var textBox = sender as TextBox;
			var treeGrid = this.sfTreeGrid;
			if (textBox.Text == "")
				treeGrid.SelectedItems.Clear();

			for (int i = 0; i < treeGrid.View.Nodes.Count; i++)
			{
				if (Provider == null)
					Provider = treeGrid.View.GetPropertyAccessProvider();

				if (treeGrid.View.Nodes[i].HasChildNodes && treeGrid.View.Nodes[i].ChildNodes.Count == 0)
				{					
					treeGrid.ExpandNode(treeGrid.View.Nodes[i]);
					treeGrid.CollapseNode(treeGrid.View.Nodes[i]);				
				}
				else if (treeGrid.View.Nodes[i].HasChildNodes)
				{
					dataRow = (treeGrid.View.Nodes[i].Item as Person);
					FindMatchText(dataRow);
					GetChildNodes(treeGrid.View.Nodes[i]);
				}
				else
				{
					dataRow = (treeGrid.View.Nodes[i].Item as Person);
					FindMatchText(dataRow);
				}
			}
		}

		/// <summary>
		/// Find the match text
		/// </summary>
		/// <param name="dataRow"></param>
		/// <returns></returns>
		private bool FindMatchText(Person dataRow)
		{
			if (MatchSearchText(sfTreeGrid.Columns[0], dataRow))
			{
				sfTreeGrid.SelectedItems.Add(dataRow);
				return true;
			}
			return false;
		}

		/// <summary>
		/// Get the child nodes
		/// </summary>
		/// <param name="node"></param>
		private void GetChildNodes(TreeNode node)
		{
			foreach (var childNode in node.ChildNodes)
			{
				dataRow = (childNode.Item as Person);
				bool foundMatchText = FindMatchText(dataRow);
				if (foundMatchText)
					sfTreeGrid.ExpandNode(node);
				GetChildNodes(childNode);
			}
		}

		/// <summary>
		/// Return the cell value that matches with the serched text 
		/// </summary>
		/// <param name="treeGridColumn"></param>
		/// <param name="record"></param>
		/// <returns></returns>
		private bool MatchSearchText(TreeGridColumn treeGridColumn, object record)
		{
			if (string.IsNullOrEmpty(textbox.Text))
				return false;

			var cellvalue = Provider.GetFormattedValue(record, treeGridColumn.MappingName);

			return cellvalue != null && cellvalue.ToString().ToLower().Equals(textbox.Text.ToString().ToLower());
		}
	}
}
