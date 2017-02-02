package md574c0eb4411c262ee4900f69e0a8f2773;


public class CourseTeeDetails_Code
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
		mono.android.Runtime.register ("CompleteGolfAppAndroid.Screens.CourseTeeDetails_Code, CompleteGolfAppAndroid, Version=1.0.6241.28317, Culture=neutral, PublicKeyToken=null", CourseTeeDetails_Code.class, __md_methods);
	}


	public CourseTeeDetails_Code () throws java.lang.Throwable
	{
		super ();
		if (getClass () == CourseTeeDetails_Code.class)
			mono.android.TypeManager.Activate ("CompleteGolfAppAndroid.Screens.CourseTeeDetails_Code, CompleteGolfAppAndroid, Version=1.0.6241.28317, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
