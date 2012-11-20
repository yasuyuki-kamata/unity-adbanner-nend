package net.oira_project.nendunityplugin;

import net.nend.android.NendAdView;
import android.app.Activity;
import android.util.Log;
import android.view.Gravity;
import android.view.ViewGroup.LayoutParams;
import android.widget.RelativeLayout;

public class NendAdBannerController {
    static final int bannerViewId = 0x661ad307; // "unique ID"
    
    static public void tryCreateBanner(final Activity activity, final int spotID, final String apiKey) {
        activity.runOnUiThread(new Runnable() {
			public void run() {
            	NendAdView nendAdView = (NendAdView)activity.findViewById(bannerViewId);
            	if (nendAdView == null) {
            		Log.d("nend Plugin", "tryCreateBanner");
            		RelativeLayout layout = new RelativeLayout(activity);
            		activity.addContentView(layout, new LayoutParams(LayoutParams.FILL_PARENT, LayoutParams.FILL_PARENT));
            		layout.setGravity(Gravity.BOTTOM);
            		// Make a banner
            		nendAdView = new NendAdView(activity, spotID, apiKey);
            		nendAdView.setId(bannerViewId);
            		layout.addView(nendAdView);
            	}
            }
        });
    }

}
