using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace HAF.Controls {
  public class PixelPerfectRadPane : RadPane {
    protected override Size ArrangeOverride(Size arrangeBounds) {
      arrangeBounds = new Size(Math.Ceiling(arrangeBounds.Width), Math.Ceiling(arrangeBounds.Height));
      return base.ArrangeOverride(arrangeBounds);
    }

    static PixelPerfectRadPane() {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(PixelPerfectRadPane),
          new FrameworkPropertyMetadata(typeof(PixelPerfectRadPane)));
    }
  }
}
