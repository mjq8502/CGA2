package md5b012d4f29d9d96d4f5c781675a3bbdb3;


public class HoleDetailsFragment
	extends android.support.v4.app.Fragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateView:(Landroid/view/LayoutInflater;Landroid/view/ViewGroup;Landroid/os/Bundle;)Landroid/view/View;:GetOnCreateView_Landroid_view_LayoutInflater_Landroid_view_ViewGroup_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("CompleteGolfAppAndroid.HoleDetailsFragment, CompleteGolfAppAndroid, Version=1.0.6219.38282, Culture=neutral, PublicKeyToken=null", HoleDetailsFragment.class, __md_methods);
	}


	public HoleDetailsFragment () throws java.lang.Throwable
	{
		super ();
		if (getClass () == HoleDetailsFragment.class)
			mono.android.TypeManager.Activate ("CompleteGolfAppAndroid.HoleDetailsFragment, CompleteGolfAppAndroid, Version=1.0.6219.38282, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public android.view.View onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2)
	{
		return n_onCreateView (p0, p1, p2);
	}

	private native android.view.View n_onCreateView (android.view.LayoutInflater p0, android.view.ViewGroup p1, android.os.Bundle p2);

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