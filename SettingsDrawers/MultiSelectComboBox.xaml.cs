using HAF.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;

namespace HAF.SettingsDrawers {
  public partial class MultiSelectComboBox : UserControl, ISettingsDrawer {
    public MultiSelectComboBox(string header, object itemsSource, string itemsPath, object selectedItemsSource, string selectedItemsPath, char? selectionSeparator = null) {
      InitializeComponent();
      // set header
      this.header.Header = header;
      // set items binding
      var itemsBinding = new Binding(itemsPath) {
        Source = itemsSource,
        Mode = BindingMode.OneWay,
      };
      BindingOperations.SetBinding(this.control, RadComboBox.ItemsSourceProperty, itemsBinding);
      // set selected items binding
      var selectedItemsBinding = new Binding(selectedItemsPath) {
        Source = selectedItemsSource,
        Mode = BindingMode.OneWay,
      };
      BindingOperations.SetBinding(this.behavior, SelectedItemsBehavior.SelectedItemsProperty, selectedItemsBinding);
      // set seperator
      if (selectionSeparator.HasValue) {
        this.control.MultipleSelectionSeparator = selectionSeparator.Value;
      }
    }

    public string DisplayName => this.header.Header;

    public string Description => null;
  }
}
