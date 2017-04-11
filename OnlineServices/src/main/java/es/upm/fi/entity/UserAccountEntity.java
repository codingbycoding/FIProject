package es.upm.fi.entity;

import javax.persistence.*;
import java.sql.Timestamp;

/**
 * Created by adam on 1/21/2017.
 */
@Entity
@Table(name = "user_accounts_tbl")
public class UserAccountEntity {

    @Id
    @Column(name="name", length = 64)
    private String name;

    @Column(name="avatar_id", length = 36, unique = true, nullable = false)
    private String avatar_id;

    @Column(name="email", length = 64)
    private String email;

    @Column(name="create_timestamp")
    private Timestamp create_timestamp;

    @Column(name="active_timestamp")
    private Timestamp active_timestamp;

    @Column(name="avatar_level")
    private int avatar_level;

    @Column(name="user_flags")
    private int user_flags;

    @Column(name="user_title", length = 64)
    private String user_title;

    public  UserAccountEntity() {}

    public  UserAccountEntity(String avatar_id, String name, String email, Timestamp create_timestamp,
                              Timestamp active_timestamp, int avatar_level, int user_flags, String user_title) {
        this.avatar_id = avatar_id;
        this.name = name;
        this.email = email;
        this.create_timestamp = create_timestamp;
        this.active_timestamp = active_timestamp;
        this.avatar_level = avatar_level;
        this.user_flags = user_flags;
        this.user_title = user_title;
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

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public Timestamp getCreate_timestamp() {
        return create_timestamp;
    }

    public void setCreate_timestamp(Timestamp create_timestamp) {
        this.create_timestamp = create_timestamp;
    }

    public Timestamp getActive_timestamp() {
        return active_timestamp;
    }

    public void setActive_timestamp(Timestamp active_timestamp) {
        this.active_timestamp = active_timestamp;
    }

    public int getAvatar_level() {
        return avatar_level;
    }

    public void setAvatar_level(int avatar_level) {
        this.avatar_level = avatar_level;
    }

    public int getUser_flags() {
        return user_flags;
    }

    public void setUser_flags(int user_flags) {
        this.user_flags = user_flags;
    }

    public String getUser_title() {
        return user_title;
    }

    public void setUser_title(String user_title) {
        this.user_title = user_title;
    }
}
