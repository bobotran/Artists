//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("Artists.Droid.Views.ListViewPage1.xaml", "Views/ListViewPage1.xaml", typeof(global::Artists.Views.ListViewPage1))]

namespace Artists.Views {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("C:\\Users\\Ryan Tran\\Documents\\Visual Studio 2017\\Projects\\Artists\\Artists\\Artists\\" +
        "Views\\ListViewPage1.xaml")]
    public partial class ListViewPage1 : global::Xamarin.Forms.ContentPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Artists.Models.HeightListView PerformersListView;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Entry PerformersEntry;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(ListViewPage1));
            PerformersListView = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Artists.Models.HeightListView>(this, "PerformersListView");
            PerformersEntry = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Entry>(this, "PerformersEntry");
        }
    }
}
