using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;

namespace HAF {
  public class SelectedItemsBehavior : Behavior<RadComboBox> {

    public INotifyCollectionChanged SelectedItems {
      get => (INotifyCollectionChanged)GetValue(SelectedItemsProperty);
      set => this.SetValue(SelectedItemsProperty, value);
    }

    public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register("SelectedItems", typeof(INotifyCollectionChanged), typeof(SelectedItemsBehavior), new PropertyMetadata(OnSelectedItemsPropertyChanged));

    private static void OnSelectedItemsPropertyChanged(DependencyObject target, DependencyPropertyChangedEventArgs args) {
      if (args.NewValue is INotifyCollectionChanged collection) {
        ((SelectedItemsBehavior)target).UpdateTransfer(args.NewValue);
        collection.CollectionChanged += ((SelectedItemsBehavior)target).ContextSelectedItems_CollectionChanged;
      }
    }

    private void UpdateTransfer(object items) {
      if (this.AssociatedObject == null) {
        return;
      }
      this.Transfer(items as IList, this.AssociatedObject.SelectedItems);
      this.AssociatedObject.SelectionChanged += this.ComboSelectionChanged;
    }

    protected override void OnAttached() {
      base.OnAttached();
    }

    private void ContextSelectedItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
      this.UnsubscribeFromEvents();
      this.Transfer(this.SelectedItems as IList, this.AssociatedObject.SelectedItems);
      this.SubscribeToEvents();
    }

    private void ComboSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e) {
      this.UnsubscribeFromEvents();
      if (e.AddedItems.Count == 0 && e.RemovedItems.Count == 1) {
        (this.SelectedItems as IList).Remove(e.RemovedItems[0]);
      } else {
        this.Transfer(this.AssociatedObject.SelectedItems, this.SelectedItems as IList);

      }
      this.SubscribeToEvents();
    }

    private void SubscribeToEvents() {
      this.AssociatedObject.SelectionChanged += this.ComboSelectionChanged;
      if (this.SelectedItems != null) {
        this.SelectedItems.CollectionChanged += this.ContextSelectedItems_CollectionChanged;
      }
    }

    private void UnsubscribeFromEvents() {
      this.AssociatedObject.SelectionChanged -= this.ComboSelectionChanged;
      if (this.SelectedItems != null) {
        this.SelectedItems.CollectionChanged -= this.ContextSelectedItems_CollectionChanged;
      }
    }

    public void Transfer(IList source, IList target) {
      if (source == null || target == null)
        return;
      if (source.Count == 0) {
        foreach (var o in target) {
          source.Add(o);
        }
      } else {
        target.Clear();
        foreach (var o in source) {
          target.Add(o);
        }
      }
    }
  }
}