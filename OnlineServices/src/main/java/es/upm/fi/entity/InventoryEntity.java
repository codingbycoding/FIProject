package es.upm.fi.entity;

import javax.persistence.*;

/**
 * Created by adam on 1/22/2017.
 */
@Entity
@Table(name="inventory_items_tbl")
public class InventoryEntity {

    @EmbeddedId
    private InventoryItemId id;

    @Column(name="item_type")
    private int item_type;

    @Column(name="item_name")
    private String item_name;

    @Column(name="item_description", length=128)
    private String inventory_description;

    @Column(name="item_count", length = 36)
    private int item_count;

    @Column(name="item_state")
    private byte[] item_state;

    public InventoryEntity() {}

    public InventoryItemId getId() {
        return id;
    }

    public void setId(InventoryItemId id) {
        this.id = id;
    }

    public int getItem_type() {
        return item_type;
    }

    public void setItem_type(int item_type) {
        this.item_type = item_type;
    }

    public String getItem_name() {
        return item_name;
    }

    public void setItem_name(String item_name) {
        this.item_name = item_name;
    }

    public String getInventory_description() {
        return inventory_description;
    }

    public void setInventory_description(String inventory_description) {
        this.inventory_description = inventory_description;
    }

    public int getItem_count() {
        return item_count;
    }

    public void setItem_count(int item_count) {
        this.item_count = item_count;
    }

    public byte[] getItem_state() {
        return item_state;
    }

    public void setItem_state(byte[] item_state) {
        this.item_state = item_state;
    }
}


