CREATE TABLE users (
    user_id UUID PRIMARY KEY,
    username VARCHAR(50) NOT NULL,
    first_name VARCHAR(50),
    last_name VARCHAR(50),
    birth_date DATE,
    country VARCHAR(50),
    city VARCHAR(50),
    user_language INT,  
    email VARCHAR(255) NOT NULL,
    biography TEXT,
    email_is_verified BOOLEAN,
    is_active BOOLEAN,
    user_location TEXT,
    website VARCHAR(255),
    created_at timestamp with time zone,
    updated_at timestamp with time zone
);

CREATE TABLE spixers (
    spider_id UUID PRIMARY KEY,
    content VARCHAR(280),  
    likes_count INT DEFAULT 0,
    created_at timestamp with time zone,
    user_id UUID,
    active BOOLEAN,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);

CREATE TABLE spixer_likes (
    like_id UUID PRIMARY KEY,
    spixer_id UUID,
    user_id UUID,
    created_at timestamp WITH TIME ZONE,
    FOREIGN KEY (spixer_id) REFERENCES spixers(spider_id) ON DELETE CASCADE,
    FOREIGN KEY (user_id) REFERENCES users(user_id) ON DELETE CASCADE
);
