CREATE OR REPLACE FUNCTION public.users_getbyid(
    p_id int
)
    RETURNS table
            (
                id                      int,
                roleid                 int,
                rolename               text,
                rolecreated_date       timestamp,
                rolelast_modified_date timestamp,
                email                   text,
                passwordhash           text,
                firstname              text,
                lastname               text,
                createddate            timestamp,
                lastmodifieddate      timestamp
            )
    LANGUAGE sql
AS
$$
SELECT u.id,
       ur.id                 AS roleid,
       ur.name               AS rolename,
       ur.createddate       AS rolecreateddate,
       ur.lastmodifieddate AS rolelastmodifieddate,
       u.email,
       u.passwordhash,
       u.firstname,
       u.lastname,
       u.createddate,
       u.lastmodifieddate
FROM public.users u
         INNER JOIN public.userroles ur on ur.id = u.roleid
WHERE u.id = p_id;
$$;