﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace HAF.Controls {
  public class PixelPerfectRadSplitContainer : RadSplitContainer {
    protected override Size ArrangeOverride(Size arrangeBounds) {
      arrangeBounds = new Size(Math.Ceiling(arrangeBounds.Width), Math.Ceiling(arrangeBounds.Height));
      return base.ArrangeOverride(arrangeBounds);
    }

    static PixelPerfectRadSplitContainer() {
      DefaultStyleKeyProperty.OverrideMetadata(typeof(PixelPerfectRadSplitContainer),
          new FrameworkPropertyMetadata(typeof(PixelPerfectRadSplitContainer)));
    }
  }
}
