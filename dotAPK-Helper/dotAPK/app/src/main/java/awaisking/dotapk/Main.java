package awaisking.dotapk;

import android.app.Activity;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.ApplicationInfo;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.content.res.Resources;
import android.graphics.Bitmap;
import android.graphics.Canvas;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.Drawable;
import android.os.Build;
import android.os.Bundle;
import android.util.Base64;
import android.util.DisplayMetrics;

import java.io.ByteArrayOutputStream;
import java.io.File;
import java.io.OutputStreamWriter;
import java.util.List;

public class Main extends Activity {
    String STOP_CMD = "awaisking.dotapk.STOP";

    BroadcastReceiver killerReceiver = new BroadcastReceiver() {
        @Override
        public void onReceive(Context context, Intent intent) {
            try {
                unregisterReceiver(killerReceiver);
            } catch (Exception ignored) {}
            Main.this.finish();
        }
    };

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        /*Intent mainIntent = new Intent(Intent.ACTION_MAIN, null);
        mainIntent.addCategory(Intent.CATEGORY_LAUNCHER);
        List<ResolveInfo> pkgAppsList = getPackageManager().queryIntentActivities(mainIntent, 0);*/

        registerReceiver(killerReceiver, new IntentFilter(STOP_CMD));

        try {
            doMagicStuff();
        } catch (PackageManager.NameNotFoundException ignored) {}
    }

    @Override
    protected void onStop() {
        super.onStop();
        try {
            unregisterReceiver(killerReceiver);
        } catch (Exception ignored) {}
        finish();
    }

    @Override
    protected void onPause() {
        super.onPause();
        try {
            unregisterReceiver(killerReceiver);
        } catch (Exception ignored) {}
        finish();
    }

    @SuppressWarnings("Deprecated")
    private Drawable getIconFromPackageName(String packageName) {
        PackageManager pm = getPackageManager();
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.ICE_CREAM_SANDWICH_MR1) {
            try {
                PackageInfo pi = pm.getPackageInfo(packageName, 0);
                Context otherAppCtx = createPackageContext(packageName, Context.CONTEXT_IGNORE_SECURITY);
                int displayMetrics[] = {DisplayMetrics.DENSITY_XHIGH, DisplayMetrics.DENSITY_HIGH, DisplayMetrics.DENSITY_TV};
                for (int displayMetric : displayMetrics) {
                    try {
                        @SuppressWarnings("deprecation")
                        Drawable d = otherAppCtx.getResources().getDrawableForDensity(pi.applicationInfo.icon, displayMetric);
                        if (d != null) return d;
                    } catch (Resources.NotFoundException e) {
//                      Log.d(TAG, "NameNotFound for" + packageName + " @ density: " + displayMetric);
                    }
                }
            } catch (Exception ignored) {}
        }

        ApplicationInfo appInfo;
        try {
            appInfo = pm.getApplicationInfo(packageName, PackageManager.GET_META_DATA);
        } catch (PackageManager.NameNotFoundException e) {
            setResult(RESULT_CANCELED);
            return null;
        }

        return appInfo.loadIcon(pm);
    }

    private void doMagicStuff() throws PackageManager.NameNotFoundException {
        PackageManager pm = getPackageManager();
        List<ApplicationInfo> packages = pm.getInstalledApplications(PackageManager.GET_META_DATA);

        String packagesInfo = "";
        for (int i=0; i<packages.size(); i++) {
            if (packages.get(i).sourceDir.contains("/system") || packages.get(i).publicSourceDir.contains("/system")) continue;

            Bitmap bitmap = drawableToBitmap(getIconFromPackageName(packages.get(i).packageName));
            String encodedBitmap = encodeToBase64(bitmap);
            encodedBitmap = encodedBitmap.replace("\r", "").replace("\n", "");
            String youKnowMe = "AWAISKING:DOTAPK:APP{" +
               /*0*/  packages.get(i).loadLabel(getPackageManager()) + ","
               /*1*/  + packages.get(i).packageName + ","
               /*2*/  + new File(packages.get(i).publicSourceDir).length() + ","
               /*3*/  + getPackageManager().getPackageInfo(packages.get(i).packageName, 0).versionName + ","
               /*4*/  + packages.get(i).targetSdkVersion + ","
               /*5*/  + "[" + packages.get(i).sourceDir + "|" + packages.get(i).publicSourceDir + "]" + ","
               /*6*/  + encodedBitmap + "}";

            packagesInfo += youKnowMe + "\r\n";
            //Log.d("AWAISKING_APP", "" + youKnowMe);
        }
        try {
            @SuppressWarnings("deprecation")
            OutputStreamWriter outputStreamWriter = new OutputStreamWriter(openFileOutput("dotAPK.txt", Context.MODE_WORLD_READABLE));
            outputStreamWriter.write(packagesInfo);
            outputStreamWriter.close();
        } catch (Exception e) {
            setResult(RESULT_CANCELED);
        }
        // finish();
        setResult(RESULT_OK);
    }

    private String encodeToBase64(Bitmap image) {
        ByteArrayOutputStream byteArrayOS = new ByteArrayOutputStream();
//        Bitmap carl;
//        Log.d("ARZAC", "" + image.getHeight());
//        if (image.getHeight() > 54) carl = Bitmap.createScaledBitmap(image, (int) (image.getHeight() / 2f), (int) (image.getWidth() / 2f), false);
//        else carl = image;
        image.compress(Bitmap.CompressFormat.PNG, 100, byteArrayOS);
//        Log.d("AWAISKING_APP", "imgH: " + image.getHeight() + " -- carlH: "+ carl.getHeight());
        try { return new String(Base64.encode(byteArrayOS.toByteArray(), Base64.DEFAULT), "UTF-8"); } catch (Exception e) { return "<ERROR>"; }
    }

    private Bitmap drawableToBitmap (Drawable drawable) {
        Bitmap bitmap;
        if (drawable instanceof BitmapDrawable) {
            BitmapDrawable bitmapDrawable = (BitmapDrawable) drawable;
            if(bitmapDrawable.getBitmap() != null) return bitmapDrawable.getBitmap();
        }
        if(drawable.getIntrinsicWidth() <= 0 || drawable.getIntrinsicHeight() <= 0)
            bitmap = Bitmap.createBitmap(1, 1, Bitmap.Config.ARGB_8888);
        else
            bitmap = Bitmap.createBitmap(drawable.getIntrinsicWidth(), drawable.getIntrinsicHeight(), Bitmap.Config.ARGB_8888);
        Canvas canvas = new Canvas(bitmap);
        drawable.setBounds(0, 0, canvas.getWidth(), canvas.getHeight());
        drawable.draw(canvas);
        return bitmap;
    }
}