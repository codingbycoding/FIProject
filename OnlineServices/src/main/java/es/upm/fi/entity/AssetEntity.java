package es.upm.fi.entity;

import javax.persistence.*;
/**
 * Created by adam on 1/22/2017.
 */
@Entity
@Table(name="assets_tbl")
public class AssetEntity {

    @Id
    @Column(name="asset_id", length=36)
    private String asset_id;

    @Column(name="name", length=64)
    private String name;

    @Column(name="description", length=128)
    private String description;

    public AssetEntity() {}

    public AssetEntity(String asset_id, String name, String description) {
        this.asset_id = asset_id;
        this.name = name;
        this.description = description;
    }

    public String getAsset_id() {
        return asset_id;
    }

    public void setAsset_id(String asset_id) {
        this.asset_id = asset_id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getDescription() {
        return description;
    }

    public void setDescription(String description) {
        this.description = description;
    }
}
