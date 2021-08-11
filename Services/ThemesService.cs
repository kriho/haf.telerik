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
  public class ThemesService : Service, IThemesService {

    public LinkedDependency MayChangeTheme { get; private set; } = new LinkedDependency();

    public LinkedEvent OnActiveThemeChanged { get; private set; } = new LinkedEvent();

    /// <summary>
    /// the list of themes that can be selected and applied
    /// </summary>
    /// <remarks>
    /// the first theme is the default theme
    /// </remarks>
    public NotifyCollection<Theme> AvailableThemes { get; private set; } = new NotifyCollection<Theme>();

    private Theme activeTheme;
    public Theme ActiveTheme {
      get { return this.activeTheme; }
      set {
        if (this.SetValue(ref this.activeTheme, value)) {
          // update telerik colors
          Telerik.Windows.Controls.Windows8Palette.Palette.MainColor = value.BackgroundColor;
          Telerik.Windows.Controls.Windows8Palette.Palette.MarkerColor = value.TextColor;
          Telerik.Windows.Controls.Windows8Palette.Palette.AccentColor = value.AccentColor;
          Telerik.Windows.Controls.Windows8Palette.Palette.BasicColor = value.LightColor;
          Telerik.Windows.Controls.Windows8Palette.Palette.StrongColor = value.StrongColor;
          // update service colors
          this.NotifyPropertyChanged(() => this.BackgroundColor);
          this.NotifyPropertyChanged(() => this.TextColor);
          this.NotifyPropertyChanged(() => this.AccentColor);
          this.NotifyPropertyChanged(() => this.LightColor);
          this.NotifyPropertyChanged(() => this.StrongColor);
          this.NotifyPropertyChanged(() => this.InfoColor);
          this.NotifyPropertyChanged(() => this.WarningColor);
          this.NotifyPropertyChanged(() => this.ErrorColor);
          this.OnActiveThemeChanged.Fire();
        }
      }
    }

    public Color BackgroundColor {
      get => this.activeTheme.BackgroundColor;
    }

    public Brush BackgroundBrush {
      get => new SolidColorBrush(this.activeTheme.BackgroundColor);
    }

    public Color TextColor {
      get => this.activeTheme.TextColor;
    }

    public Brush TextBrush {
      get => new SolidColorBrush(this.activeTheme.TextColor);
    }

    public Color AccentColor {
      get => this.activeTheme.AccentColor;
    }
    public Brush AccentBrush {
      get => new SolidColorBrush(this.activeTheme.AccentColor);
    }

    public Color LightColor {
      get => this.activeTheme.LightColor;
    }

    public Brush LightBrush {
      get => new SolidColorBrush(this.activeTheme.LightColor);
    }

    public Color StrongColor {
      get => this.activeTheme.StrongColor;
    }

    public Brush StrongBrush {
      get => new SolidColorBrush(this.activeTheme.StrongColor);
    }

    public Color InfoColor {
      get => this.activeTheme.InfoColor;
    }

    public Brush InfoBrush {
      get => new SolidColorBrush(this.activeTheme.InfoColor);
    }

    public Color WarningColor {
      get => this.activeTheme.WarningColor;
    }

    public Brush WarningBrush {
      get => new SolidColorBrush(this.activeTheme.WarningColor);
    }

    public Color ErrorColor {
      get => this.activeTheme.ErrorColor;
    }

    public Brush ErrorBrush {
      get => new SolidColorBrush(this.activeTheme.ErrorColor);
    }

    public RelayCommand<Theme> DoSetTheme { get; private set; }

    public ThemesService() {
      this.DoSetTheme = new RelayCommand<Theme>(theme => {
        this.ActiveTheme = theme;
      }, (theme) => {
        return theme != null && this.MayChangeTheme;
      });
      this.MayChangeTheme.RegisterUpdate(() => {
        this.DoSetTheme.RaiseCanExecuteChanged();
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

    public override void LoadConfiguration(ServiceConfiguration configuration) {
      Theme theme = null;
      if (configuration.ReadStringValue("theme", out var themeName)) {
        theme = this.AvailableThemes.FirstOrDefault(t => t.Name == themeName);
      }
      if(theme == null) {
        theme = this.AvailableThemes.FirstOrDefault();
      }
      if(theme != null) {
        this.ActiveTheme = theme;
      }
    }

    public override void SaveConfiguration(ServiceConfiguration configuration) {
      configuration.WriteValue("theme", this.activeTheme.Name);
    }
  }
}
