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
        if (property == null || property == "Background") {
          Telerik.Windows.Controls.Windows8Palette.Palette.MainColor = this.ActiveTheme.Background;
        }
        if(property == null || property == "Light") {
          Telerik.Windows.Controls.Windows8Palette.Palette.BasicColor = this.ActiveTheme.Light;
        }
        if(property == null || property == "Strong") {
          Telerik.Windows.Controls.Windows8Palette.Palette.StrongColor = this.ActiveTheme.Strong;
        }
        if (property == null || property == "Text") {
          Telerik.Windows.Controls.Windows8Palette.Palette.MarkerColor = this.ActiveTheme.Text;
        }
        if (property == null || property == "Accent") {
          Telerik.Windows.Controls.Windows8Palette.Palette.AccentColor = this.ActiveTheme.Accent;
        }
      } else if (this.TelerikTheme == TelerikTheme.Office2016) {
        if (property == null || property == "DisabledOpacity") {
          Telerik.Windows.Controls.Office2016Palette.Palette.DisabledOpacity = this.ActiveTheme.DisabledOpacity;
        }
        if (property == null || property == "Background") {
          Telerik.Windows.Controls.Office2016Palette.Palette.AlternativeColor = this.ActiveTheme.Background;
          Telerik.Windows.Controls.Office2016Palette.Palette.MouseOverColor = this.ActiveTheme.Background;
        }
        if(property == null || property == "Control") {
          Telerik.Windows.Controls.Office2016Palette.Palette.MainColor = this.ActiveTheme.Control;
        }
        if(property == null || property == "Light") {
          Telerik.Windows.Controls.Office2016Palette.Palette.PrimaryColor = this.ActiveTheme.Light;
          Telerik.Windows.Controls.Office2016Palette.Palette.SelectedColor = this.ActiveTheme.Light;
        }
        if(property == null || property == "Strong") {
          Telerik.Windows.Controls.Office2016Palette.Palette.BasicColor = this.ActiveTheme.Strong;
        }
        if(property == null || property == "SecondaryColor") {
          Telerik.Windows.Controls.Office2016Palette.Palette.IconColor = this.ActiveTheme.Secondary;
        }
        if (property == null || property == "Text") {
          Telerik.Windows.Controls.Office2016Palette.Palette.MarkerColor = this.ActiveTheme.Text;
        }
        if(property == null || property == "InvertedText") {
          Telerik.Windows.Controls.Office2016Palette.Palette.MarkerInvertedColor = this.ActiveTheme.InvertedText;
        }
        if (property == null || property == "Accent") {
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentColor = this.ActiveTheme.Accent;
          Telerik.Windows.Controls.Office2016Palette.Palette.ComplementaryColor = this.ActiveTheme.Accent;
        }
        if(property == null || property == "Action") {
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentFocusedColor = this.ActiveTheme.Action;
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentMouseOverColor = this.ActiveTheme.Action;
          Telerik.Windows.Controls.Office2016Palette.Palette.PressedColor = this.ActiveTheme.Action;
          Telerik.Windows.Controls.Office2016Palette.Palette.AccentPressedColor = this.ActiveTheme.Action;
        }
      }
    }
  }
}
