package es.upm.fi.utils;

import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.ByteArrayOutputStream;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.util.Base64;
/**
 * Created by Adam on 2/20/2017.
 */
public class SerializeUtil {

    public static String object2String(Object obj) {
        String serializedObject = "";
        try {
            ByteArrayOutputStream bo = new ByteArrayOutputStream();
            ObjectOutputStream so = new ObjectOutputStream(bo);
            so.writeObject(obj);
            so.close();

            serializedObject = Base64.getEncoder().encodeToString(bo.toByteArray());
        } catch (IOException e) {
            UTLogger.error(e.toString());
        }

        return serializedObject;
    }

    public static Object getObjectFromString(String serializedObject) {
        Object obj =  null;
        try {
            byte [] b = Base64.getDecoder().decode( serializedObject );
            ByteArrayInputStream bi = new ByteArrayInputStream(b);
            ObjectInputStream si = new ObjectInputStream(bi);
            obj = si.readObject();
            si.close();
        } catch (IOException e) {
            UTLogger.error(e.toString());
        } catch(Exception e) {
            UTLogger.error(e.toString());
        }

        return obj;
    }
}
