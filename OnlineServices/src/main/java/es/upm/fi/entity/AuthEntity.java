package es.upm.fi.entity;

import javax.persistence.*;
/**
 * Created by adam on 1/22/2017.
 */
@Entity
@Table(name="auth_tbl")
public class AuthEntity {

    @Id
    @Column(name="name", length=36)
    private String name;

    @Column(name="avatar_id", length=36)
    private String avatar_id;

    @Column(name="password_hash", length=32)
    private String password_hash;

    @Column(name="password_salt", length=32)
    private String password_salt;

    @Column(name="account_type", length=32)
    private String account_type;

    public AuthEntity() {}

    public AuthEntity(String name) {
        this.name = name;
    }

    public AuthEntity(String name, String avatar_id, String password_hash, String password_salt, String account_type) {
        this.name = name;
        this.avatar_id = avatar_id;
        this.password_hash = password_hash;
        this.password_salt = password_salt;
        this.account_type = account_type;
    }

    public String getName() {
        return name;
    }

    public void setName(String avatar_id) {
        this.name = name;
    }

    public String getAvatar_id() {
        return avatar_id;
    }

    public void setAvatar_id(String avatar_id) {
        this.avatar_id = avatar_id;
    }

    public String getPassword_hash() {
        return password_hash;
    }

    public void setPassword_hash(String password_hash) {
        this.password_hash = password_hash;
    }

    public String getPassword_salt() {
        return password_salt;
    }

    public void setPassword_salt(String password_salt) {
        this.password_salt = password_salt;
    }

    public String getAccount_type() {
        return account_type;
    }

    public void setAccount_type(String account_type) {
        this.account_type = account_type;
    }
}
