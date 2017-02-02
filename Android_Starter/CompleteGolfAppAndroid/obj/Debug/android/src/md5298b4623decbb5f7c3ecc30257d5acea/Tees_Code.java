package md5298b4623decbb5f7c3ecc30257d5acea;


public class Tees_Code
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
		mono.android.Runtime.register ("CompleteGolfAppAndroid.Screens.Tees_Code, CompleteGolfAppAndroid, Version=1.0.6222.36703, Culture=neutral, PublicKeyToken=null", Tees_Code.class, __md_methods);
	}


	public Tees_Code () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Tees_Code.class)
			mono.android.TypeManager.Activate ("CompleteGolfAppAndroid.Screens.Tees_Code, CompleteGolfAppAndroid, Version=1.0.6222.36703, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
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
