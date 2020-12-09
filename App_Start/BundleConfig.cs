using System.Web;
using System.Web.Optimization;

namespace VOD
{
	public class BundleConfig
	{
		// Aby uzyskać więcej informacji o grupowaniu, odwiedź stronę https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/lib").Include(
						 "~/Scripts/bootstrap.js",
						 "~/Scripts/bootbox.js",
						 "~/Scripts/toastr.js",
						 "~/Scripts/typeahead.bundle.js",
						 "~/Scripts/jquery-{version}.js",
						 "~/Scripts/DataTables/jquery.dataTables.js",
						  "~/Scripts/DataTables/dataTables.bootstrap.js"));

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));

			// Użyj wersji deweloperskiej biblioteki Modernizr do nauki i opracowywania rozwiązań. Następnie, kiedy wszystko będzie
			// gotowe do produkcji, użyj narzędzia do kompilowania ze strony https://modernizr.com, aby wybrać wyłącznie potrzebne testy.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));


			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/typeahead.css",
					  "~/Content/toastr.css",
					  "~/Content/DataTables/css/dataTables.bootstrap.css",
					  "~/Content/Site.css"));
		}
	}
}
