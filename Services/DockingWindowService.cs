using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;

namespace HAF {
  [Export(typeof(IDockingWindowService)), Export(typeof(IWindowService)), PartCreationPolicy(CreationPolicy.Shared)]
  public class DockingWindowService : WindowService, IDockingWindowService {
    private RadDocking docking;
    public object Docking {
      get {
        return this.docking;
      }
      set {
        if (value is RadDocking d) {
          this.docking = d;
        } else {
          this.docking = null;
        }
      }
    }

    public string GetWindowLayout() {
      using (var stream = new MemoryStream()) {
        this.docking.SaveLayout(stream);
        return Convert.ToBase64String(stream.GetBuffer());
      }
    }

    public void SetWindowLayout(string layout) {
      using (var stream = new MemoryStream(Convert.FromBase64String(layout))) {
        this.docking.LoadLayout(stream);
      }
    }

    public void ShowPane(string name) {
      var existingPane = this.docking.Panes.FirstOrDefault(p => p.Header.ToString() == name);
      if (existingPane != null) {
        existingPane.IsActive = true;
      }
    }

    public void ShowPane(string name, Type viewType, bool canUserClose) {
      var existingPane = this.docking.Panes.FirstOrDefault(p => p.Header.ToString() == name);
      if (existingPane != null) {
        if(existingPane.Content == null) {
          existingPane.Content = Activator.CreateInstance(viewType);
        }
        existingPane.IsHidden = false;
        existingPane.IsActive = true;
      } else {
        if (this.docking.ActivePane != null) {
          var pane = new Telerik.Windows.Controls.RadPane() {
            Content = Activator.CreateInstance(viewType),
            Header = name,
            CanUserClose = canUserClose,
            CanUserPin = false,
          };
          Telerik.Windows.Controls.RadDocking.SetSerializationTag(pane, name.Replace(" ", ""));
          this.docking.ActivePane.PaneGroup.Items.Add(pane);
        } else {
          Log.Error("select a pane to add new panes to the same pane group");
        }
      }
    }
  }
}