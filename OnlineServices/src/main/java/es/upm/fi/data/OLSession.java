package es.upm.fi.data;

/**
 * Created by Adam on 3/25/2017.
 */
public class OLSession {
    private static long curSessionId = 1;

    public static long createSession(String userId) {
        return curSessionId++;
    }
}
