﻿using System;
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

namespace HAF.SettingsDrawers {
  public partial class ThemeSelector: UserControl, ISettingsDrawer {
    public ThemeSelector(IThemesService themesService) {
      InitializeComponent();
      this.DataContext = themesService;
    }

    public string DisplayName => "Theme";

    public string Description => null;
  }
}
