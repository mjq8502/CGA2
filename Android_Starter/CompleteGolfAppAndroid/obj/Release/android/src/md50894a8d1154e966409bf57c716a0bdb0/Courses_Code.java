package md50894a8d1154e966409bf57c716a0bdb0;


public class Courses_Code
	extends android.app.Activity
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
		mono.android.Runtime.register ("CompleteGolfAppAndroid.Screens.Courses_Code, CompleteGolfAppAndroid, Version=1.0.6224.20223, Culture=neutral, PublicKeyToken=null", Courses_Code.class, __md_methods);
	}


	public Courses_Code () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Courses_Code.class)
			mono.android.TypeManager.Activate ("CompleteGolfAppAndroid.Screens.Courses_Code, CompleteGolfAppAndroid, Version=1.0.6224.20223, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
