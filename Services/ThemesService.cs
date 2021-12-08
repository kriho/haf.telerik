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

  public enum TelerikTheme {
    Windows8,
    Office2016,
  }

  [Export(typeof(IThemesService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class TelerikThemesService : ThemesService {

    public TelerikTheme TelerikTheme { get; set; } = TelerikTheme.Office2016;

    public TelerikThemesService() {
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
      // set fixed font size
      Telerik.Windows.Controls.Office2016Palette.Palette.FontSizeS = 14;
      Telerik.Windows.Controls.Office2016Palette.Palette.FontSize = 14;
      Telerik.Windows.Controls.Office2016Palette.Palette.FontSizeL = 16;
    }

    protected override void ApplyTheme(ITheme theme, string property = null) {
      base.ApplyTheme(theme, property);
      // update telerik colors
      if (this.TelerikTheme == TelerikTheme.Windows8) {
        if (property == null || property == "BackgroundColor") {
          Telerik.Windows.Controls.Windows8Palette.Palette.MainColor = this.ActiveTheme.BackgroundColor;
        }
        if (property == null || property == "TextColor") {
          Telerik.Windows.Controls.Windows8Palette.Palette.MarkerColor = this.ActiveTheme.TextColor;
        }
        if (property == null || property == "AccentColor") {
          Telerik.Windows.Controls.Windows8Palette.Palette.AccentColor = this.ActiveTheme.AccentColor;
        }
        if (property == null || property == "LightColor") {
          Telerik.Windows.Controls.Windows8Palette.Palette.BasicColor = this.ActiveTheme.LightColor;
        }
        if (property == null || property == "StrongColor") {
          Telerik.Windows.Controls.Windows8Palette.Palette.StrongColor = this.ActiveTheme.StrongColor;
        }
      } else if (this.TelerikTheme == TelerikTheme.Office2016) {
        if (property == null || property == "ActionColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentFocusedColor = this.ActiveTheme.ActionColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentMouseOverColor = this.ActiveTheme.ActionColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.PressedColor = this.ActiveTheme.ActionColor;
        }
        if (property == null || property == "ControlColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.MainColor = this.ActiveTheme.ControlColor;
        }
        if (property == null || property == "BackgroundColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.AlternativeColor = this.ActiveTheme.BackgroundColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.MouseOverColor = this.ActiveTheme.BackgroundColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.MarkerInvertedColor = this.ActiveTheme.BackgroundColor;
        }
        if (property == null || property == "TextColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.MarkerColor = this.ActiveTheme.TextColor;
        }
        if (property == null || property == "AccentColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentColor = this.ActiveTheme.AccentColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.ComplementaryColor = this.ActiveTheme.AccentColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentPressedColor = this.ActiveTheme.AccentColor;
        }
        if (property == null || property == "LightColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.PrimaryColor = this.ActiveTheme.LightColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.SelectedColor = this.ActiveTheme.LightColor;
        }
        if (property == null || property == "StrongColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.IconColor = this.ActiveTheme.StrongColor;
          Telerik.Windows.Controls.Office2016Palette.Palette.BasicColor = this.ActiveTheme.StrongColor;
        }
      }
    }
  }
}
