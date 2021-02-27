DROP FUNCTION IF EXISTS public.poll_answers_get_by_poll_id;

CREATE OR REPLACE FUNCTION public.poll_answers_get_by_poll_id(p_poll_id int)
    RETURNS table
            (
                id             int,
                user_id        int,
                poll_option_id int,
                poll_id        int
            )
    LANGUAGE sql
AS
$$
SELECT pa.id,
       pa.user_id,
       pa.poll_option_id,
       po.poll_id
FROM public.poll_answers pa
         INNER JOIN public.poll_options po ON po.id = pa.poll_option_id
WHERE po.poll_id = p_poll_id;
$$