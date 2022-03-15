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
using Telerik.Windows.Controls.ChartView;

namespace HAF.Behaviors {
  public class EnablePanAndZoom: Behavior<ChartPanAndZoomBehavior> {
    protected override void OnAttached() {
      var keyCombo = new ChartKeyCombination();
      keyCombo.MouseButtons.Add(MouseButton.Right);
      this.AssociatedObject.DragToZoomKeyCombinations.Add(keyCombo);
      keyCombo = new ChartKeyCombination();
      keyCombo.MouseButtons.Add(MouseButton.Left);
      this.AssociatedObject.DragToPanKeyCombinations.Add(keyCombo);
      _ = Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render , new Action(() => {
        this.AssociatedObject.Chart.PreviewMouseWheel += this.Chart_PreviewMouseWheel;
      }));
    }

    protected override void OnDetaching() {
      this.AssociatedObject.Chart.PreviewMouseWheel -= this.Chart_PreviewMouseWheel;
    }

    private void Chart_PreviewMouseWheel(object sender, MouseWheelEventArgs e) {
      if(Keyboard.IsKeyDown(Key.LeftCtrl)) {
        this.AssociatedObject.MouseWheelMode = ChartMouseWheelMode.ZoomVertically;
      } else if (Keyboard.IsKeyDown(Key.LeftAlt)) {
        this.AssociatedObject.MouseWheelMode = ChartMouseWheelMode.Zoom;
      } else {
        this.AssociatedObject.MouseWheelMode = ChartMouseWheelMode.ZoomHorizontally;
      }
    }
  }
}
