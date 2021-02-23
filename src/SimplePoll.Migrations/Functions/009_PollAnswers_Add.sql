DROP FUNCTION IF EXISTS public.poll_answers_add;

CREATE OR REPLACE FUNCTION public.poll_answers_add(p_poll_option_id int,
                                                   p_user_id int)
    RETURNS int
    LANGUAGE sql
AS
$$
INSERT INTO public.poll_answers (poll_option_id, user_id)
VALUES (p_poll_option_id, p_user_id)
RETURNING id;
$$