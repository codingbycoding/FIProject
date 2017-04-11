package es.upm.fi.entity;

import javax.persistence.*;

/**
 * Created by adam on 1/22/2017.
 */
@Entity
@Table(name="inventory_folders_tbl")
public class InventoryFolderEntity {

    @Column(name="folder_name", length=64)
    private String folder_name;

    @Column(name="type")
    private int type;

    @Column(name="version")
    private int version;

    @Id
    @Column(name="folder_id", length=36)
    private String folder_id;

    @Column(name="avatar_id", length=36)
    private String avatar_id;

    @Column(name="parent_folder_id", length=36)
    private String parent_folder_id;

    public InventoryFolderEntity() {}

    public InventoryFolderEntity(String folder_name, int type, int version, String folder_id,
                                 String avatar_id, String parent_folder_id) {
        this.folder_name = folder_name;
        this.type = type;
        this.version = version;
        this.folder_id = folder_id;
        this.avatar_id = avatar_id;
        this.parent_folder_id = parent_folder_id;
    }

    public String getFolder_name() {
        return folder_name;
    }

    public void setFolder_name(String folder_name) {
        this.folder_name = folder_name;
    }

    public int getType() {
        return type;
    }

    public void setType(int type) {
        this.type = type;
    }

    public int getVersion() {
        return version;
    }

    public void setVersion(int version) {
        this.version = version;
    }

    public String getFolder_id() {
        return folder_id;
    }

    public void setFolder_id(String folder_id) {
        this.folder_id = folder_id;
    }

    public String getAvatar_id() {
        return avatar_id;
    }

    public void setAvatar_id(String avatar_id) {
        this.avatar_id = avatar_id;
    }

    public String getParent_folder_id() {
        return parent_folder_id;
    }

    public void setParent_folder_id(String parent_folder_id) {
        this.parent_folder_id = parent_folder_id;
    }
}
