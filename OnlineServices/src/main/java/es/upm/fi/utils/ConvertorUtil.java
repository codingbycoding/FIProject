package es.upm.fi.utils;

/**
 * Created by Adam on 2/27/2017.
 */
public class ConvertorUtil {
    public static String ConStr2Remote(String str) {
        String[] strs = str.split("remote address =");

        UTLogger.debug("ConStr2Remote str:" + str);
        UTLogger.debug("ConStr2Remote remote address=:" + strs[1]);
        return strs[1];
    }
}
