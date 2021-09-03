using HAF.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Deployment.Application;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml;

namespace HAF {

  [Export(typeof(IThemesService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class TelerikThemesService: ThemesService {

    public TelerikThemesService() {
      this.OnActiveThemeChanged.Register(() => {
        // update telerik colors
        Telerik.Windows.Controls.Windows8Palette.Palette.MainColor = this.ActiveTheme.BackgroundColor;
        Telerik.Windows.Controls.Windows8Palette.Palette.MarkerColor = this.ActiveTheme.TextColor;
        Telerik.Windows.Controls.Windows8Palette.Palette.AccentColor = this.ActiveTheme.AccentColor;
        Telerik.Windows.Controls.Windows8Palette.Palette.BasicColor = this.ActiveTheme.LightColor;
        Telerik.Windows.Controls.Windows8Palette.Palette.StrongColor = this.ActiveTheme.StrongColor;
      });
      // disable touch manager for increased performance 
      Telerik.Windows.Input.Touch.TouchManager.IsTouchEnabled = false;
      // set fixed font size
      Telerik.Windows.Controls.Windows8Palette.Palette.FontSizeXS = 15;
      Telerik.Windows.Controls.Windows8Palette.Palette.FontSizeS = 15;
      Telerik.Windows.Controls.Windows8Palette.Palette.FontSize = 15;
      Telerik.Windows.Controls.Windows8Palette.Palette.FontSizeL = 15;
      Telerik.Windows.Controls.Windows8Palette.Palette.FontSizeXL = 15;
      Telerik.Windows.Controls.Windows8Palette.Palette.FontSizeXXL = 15;
      Telerik.Windows.Controls.Windows8Palette.Palette.FontSizeXXXL = 15;
      // set fonts
      Telerik.Windows.Controls.Windows8Palette.Palette.FontFamily = new FontFamily("Segoe UI");
      Telerik.Windows.Controls.Windows8Palette.Palette.FontFamilyLight = new FontFamily("Segoe UI Light");
      Telerik.Windows.Controls.Windows8Palette.Palette.FontFamilyStrong = new FontFamily("Segoe UI Semibold");
    }
  }
}
