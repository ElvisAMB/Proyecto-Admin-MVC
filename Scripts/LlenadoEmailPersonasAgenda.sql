--update agenda.AgendaTelefonica set email = replace(lower(nombres),' ','')--+'@confianza.com.ec'
--update agenda.AgendaTelefonica set email = null
--update agenda.AgendaTelefonica set email = replace(lower(email),'.','')
--update agenda.AgendaTelefonica set email = email + '@confianza.com.ec'
select * from agenda.AgendaTelefonica


--select case when Len(apellidos) > 0 then lower(replace(replace(nombres,'.',''),' ','') + '.' + apellidos) end from agenda.AgendaTelefonica
--update agenda.AgendaTelefonica set email = (case when Len(apellidos) > 0 then lower(replace(replace(nombres,'.',''),' ','') + '.' + apellidos) end)


--alter table agenda.AgendaTelefonica add id bigint identity(1,1)