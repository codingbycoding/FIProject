package es.upm.fi.entity;

import javax.persistence.*;
import org.hibernate.type.LobType;
/**
 * Created by adam on 1/22/2017.
 */

@Entity
@Table(name = "avatars_tbl")
public class AvatarEntity {

    @Column(name="avatar_id", length=36)
    private String avatar_id;

    @Id
    @Column(name="name", length=32)
    private String name;

    @Column(name="avatar_state")
    private String avatar_state;

    public AvatarEntity() {}

    public AvatarEntity(String avatar_id, String name, String avatar_state) {
        this.avatar_id = avatar_id;
        this.name = name;
        this.avatar_state = avatar_state;
    }

    public String getAvatar_id() {
        return avatar_id;
    }

    public void setAvatar_id(String avatar_id) {
        this.avatar_id = avatar_id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public String getAvatar_state() {
        return avatar_state;
    }

    public void setAvatar_state(String avatar_state) {
        this.avatar_state = avatar_state;
    }
}
