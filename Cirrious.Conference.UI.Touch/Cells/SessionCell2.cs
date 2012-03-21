using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using Cirrious.MvvmCross.Binding.Touch.Views;
using MonoTouch.ObjCRuntime;

namespace Cirrious.Conference.UI.Touch
{
	public partial class SessionCell2 : MvxBindableTableViewCell
	{
		public static NSString Identifier = new NSString("SessionCell2");
        public const string BindingText = "{'SpeakerText':{'Path':'Item.Session.SpeakerKey'},'MainText':{'Path':'Item.Session.Title'},'RoomText':{'Path':'Item.Session','Converter':'SessionSmallDetails','ConverterParameter':'SmallDetailsFormat'}}";
		
		public static SessionCell2 LoadFromNib()
		{
			// this bizarre loading sequence is modified from a blog post on AlexYork.net
			// basically we create an empty cell in C#, then pass that through a NIB loading, which then magically
			// gives us a new cell back in MonoTouch again
			var cell = new SessionCell2("{}");
			var views = NSBundle.MainBundle.LoadNib("SessionCell2", cell, null);
			var cell2 = Runtime.GetNSObject( views.ValueAt(0) ) as SessionCell2;
			cell2.Initialise();
			return cell2;
		}
		
		public SessionCell2(IntPtr handle)
			: base(BindingText, handle)
		{
		}		
		
		public SessionCell2 ()
			: base(BindingText, MonoTouch.UIKit.UITableViewCellStyle.Default, Identifier)
		{
		}

		public SessionCell2 (string bindingText)
			: base(bindingText, MonoTouch.UIKit.UITableViewCellStyle.Default, Identifier)
		{
		}
		
		private void Initialise()
		{
			Image1.Image = UIImage.FromFile("ConfResources/Images/appbar.people.png");
			Image2.Image = UIImage.FromFile("ConfResources/Images/appbar.city.png");
		}	
			
		protected override void Dispose (bool disposing)
		{
			if (disposing)
			{
				// TODO - really not sure that Dispose is the right place for this call 
				// - but couldn't see how else to do this in a TableViewCell
				ReleaseDesignerOutlets();
			}
			
			base.Dispose (disposing);
		} 

		public override string ReuseIdentifier 
		{
			get 
			{
				return Identifier.ToString();
			}
		}
		
		public string MainText
		{
			get { return TitleLabel.Text; }
			set { if (TitleLabel != null) TitleLabel.Text = value; }
		}
		
		public string SpeakerText
		{
			get { return Label1.Text; }
			set { if (Label1 != null) Label1.Text = value; }
		}
		
		public string RoomText
		{
			get { return Label2.Text; }
			set { if (Label2 != null) Label2.Text = value; }
		}
	}
}
