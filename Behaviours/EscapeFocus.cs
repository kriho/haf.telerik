using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;

namespace HAF.Behaviors {
  public class EscapeFocus : Behavior<TextBoxBase> {
    public static readonly DependencyProperty TargetProperty = DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(EscapeFocus), new PropertyMetadata(null));
    public FrameworkElement Target {
      get { return (FrameworkElement)this.GetValue(EscapeFocus.TargetProperty); }
      set { this.SetValue(EscapeFocus.TargetProperty, value); }
    }

    protected override void OnAttached() {
      this.AssociatedObject.KeyDown += this.AssociatedObject_KeyDown;
    }

    protected override void OnDetaching() {
      this.AssociatedObject.KeyDown -= this.AssociatedObject_KeyDown;
    }

    private void AssociatedObject_KeyDown(object sender, KeyEventArgs e) {
      if (e.Key == Key.Escape) {
        this.Target.Focus();
      }
    }
  }
}
