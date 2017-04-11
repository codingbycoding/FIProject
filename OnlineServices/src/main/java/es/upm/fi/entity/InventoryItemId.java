package es.upm.fi.entity;

import javax.persistence.Column;
import javax.persistence.Embeddable;
import java.io.Serializable;
import java.util.Objects;


/**
 * Created by Adam on 3/3/2017.
 */
@Embeddable
public class InventoryItemId implements Serializable {
    @Column(name = "avatar_id")
    private String avatar_id;

    @Column(name = "item_id")
    private int item_id;

    public String getAvatar_id() {
        return avatar_id;
    }

    public void setAvatar_id(String avatar_id) {
        this.avatar_id = avatar_id;
    }

    public int getItem_id() {
        return item_id;
    }

    public void setItem_id(int item_id) {
        this.item_id = item_id;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (!(o instanceof InventoryItemId)) return false;
        InventoryItemId that = (InventoryItemId) o;
        return Objects.equals(this.getAvatar_id(), that.getAvatar_id()) &&
                Objects.equals(this.getItem_id(), that.getItem_id());
    }


    @Override
    public int hashCode() {
        return Objects.hash(getAvatar_id(), getItem_id());
    }
}
