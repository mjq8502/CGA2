package md51499dbce911473f15af31892a1e694e4;


public class CourseDetailsView_Code
	extends android.support.v4.app.FragmentActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onResume:()V:GetOnResumeHandler\n" +
			"";
		mono.android.Runtime.register ("CompleteGolfAppAndroid.Screens.CourseDetailsView_Code, CompleteGolfAppAndroid, Version=1.0.6224.23588, Culture=neutral, PublicKeyToken=null", CourseDetailsView_Code.class, __md_methods);
	}


	public CourseDetailsView_Code () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CourseDetailsView_Code.class)
			mono.android.TypeManager.Activate ("CompleteGolfAppAndroid.Screens.CourseDetailsView_Code, CompleteGolfAppAndroid, Version=1.0.6224.23588, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onResume ()
	{
		n_onResume ();
	}

	private native void n_onResume ();

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
