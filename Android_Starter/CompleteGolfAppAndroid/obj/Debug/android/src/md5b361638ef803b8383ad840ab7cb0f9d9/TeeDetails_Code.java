package md5b361638ef803b8383ad840ab7cb0f9d9;


public class TeeDetails_Code
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CompleteGolfAppAndroid.Screens.TeeDetails_Code, CompleteGolfAppAndroid, Version=1.0.6241.31776, Culture=neutral, PublicKeyToken=null", TeeDetails_Code.class, __md_methods);
	}


	public TeeDetails_Code () throws java.lang.Throwable
	{
		super ();
		if (getClass () == TeeDetails_Code.class)
			mono.android.TypeManager.Activate ("CompleteGolfAppAndroid.Screens.TeeDetails_Code, CompleteGolfAppAndroid, Version=1.0.6241.31776, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
